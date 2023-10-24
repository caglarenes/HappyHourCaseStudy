using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionManager : ScopedSingleton<SelectionManager>
{
    public LayerMask MapLayer;
    public LayerMask CharacterLayer;
    public LayerMask WoodSourceLayer;

    public bool TryGetSelectedMapPoint(out Vector3 selectedMapPoint)
    {
        selectedMapPoint = Vector3.zero;

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return false;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hitInfo, 1000, MapLayer))
        {
            return false;
        }

        selectedMapPoint = hitInfo.point;

        return true;
    }

    public bool TryGetSelectedWoodSource(out WoodSource selectedWoodSource)
    {
        selectedWoodSource = null;

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return false;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hitInfo, 1000, WoodSourceLayer))
        {
            return false;
        }

        selectedWoodSource = hitInfo.collider.gameObject.GetComponentInParent<WoodSource>();

        return true;
    }


    public bool TryGetSelectedCharacter(out Character selectedCharacter)
    {
        selectedCharacter = null;

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return false;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hitInfo, 1000, CharacterLayer))
        {
            return false;
        }

        selectedCharacter = hitInfo.collider.gameObject.GetComponentInParent<Character>();

        if (selectedCharacter.CharacterTeam != GameManager.Instance.PlayerTeam)
        {
            selectedCharacter = null;
            return false;
        }

        return true;
    }
}
