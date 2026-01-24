using TMPro;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _property;
    [SerializeField] private Enemy _enemy;

    private void Start()
    {
        _name.text = _enemy.GetName();
        _property.text = _enemy.GetStat();
    }
}
