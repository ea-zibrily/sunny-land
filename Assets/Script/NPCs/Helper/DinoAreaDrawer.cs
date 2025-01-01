using UnityEngine;

namespace Sunny.NPCs
{
    public class DinoAreaDrawer : MonoBehaviour
    {
        // Reference
        private DinoBT _dinoBTs;

        private void Awake()
        {
            _dinoBTs = GetComponent<DinoBT>();
        }

        private void OnDrawGizmos()
        {
            if (_dinoBTs == null) return;
            var spaces = _dinoBTs.SpaceDatas;
            foreach (var space in spaces)
            {
                var targetColor = GetColor(space.Type);
                Gizmos.color = targetColor;
                Gizmos.DrawWireSphere(transform.position, space.Radius);
            }
        }
        
        private Color GetColor(SpaceType space)
        {
            return space switch
            {
                SpaceType.Initimate => Color.magenta,
                SpaceType.Personal => Color.green,
                SpaceType.Public => Color.blue,
                SpaceType.Getter => Color.red,
                _ => Color.black
            };
        }
    }
}
