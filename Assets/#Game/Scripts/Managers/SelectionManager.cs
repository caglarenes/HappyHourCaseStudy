using UnityEngine;

public class SelectionManager : ScopedSingleton<SelectionManager>
{
    public LayerMask MapLayer;
    public LayerMask CharacterLayer;

    public bool TryGetSelectedMapPoint(out Vector3 selectedMapPoint)
    {
        selectedMapPoint = Vector3.zero;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (!Physics.Raycast(ray, out var hitInfo, 1000, MapLayer))
        {
            return false;
        }

        selectedMapPoint = hitInfo.point;

        return true;
    }


    public bool TryGetSelectedCharacter(out Character selectedCharacter)
    {
        selectedCharacter = null;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (!Physics.Raycast(ray, out var hitInfo, 1000, CharacterLayer))
        {
            return false;
        }

        selectedCharacter = hitInfo.collider.gameObject.GetComponentInParent<Character>();

        return true;
    }
}
