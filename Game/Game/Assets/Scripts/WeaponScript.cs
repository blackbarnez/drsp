using UnityEngine;

/// Запуск прожектайла
public class WeaponScript : MonoBehaviour
{
    //--------------------------------
    // 1 – Переменные дизайнера (меняющиеся в инспекторе)
    //--------------------------------
    /// Префаб снаряда для стрельбы

    public Transform shotPrefab;

    /// Время перезарядки в секундах
    public float shootingRate = 0.25f;

    //--------------------------------
    // 2 - Перезарядка
    //--------------------------------

    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }
    //--------------------------------
    // 3 - Стрельба из другого скрипта
    //--------------------------------
    /// Создайте новый снаряд, если это возможно
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            // Создайте новый выстрел
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Определите положение
            shotTransform.position = transform.position;

            // Свойство врага
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            // Сделайте так, чтобы выстрел всегда был направлен на него
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                if(gameObject.CompareTag("Enemy"))
                move.direction = this.transform.localPosition.normalized;
                else move.direction = this.transform.right; // в двухмерном пространстве это будет справа от спрайта
            }
        }
    }

    /// Готово ли оружие выпустить новый снаряд?
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}
