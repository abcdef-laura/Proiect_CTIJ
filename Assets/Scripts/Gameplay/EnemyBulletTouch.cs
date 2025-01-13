using Platformer.Core;
using Platformer.Mechanics;
using UnityEngine;
using Platformer.Model;
using static Platformer.Core.Simulation;
using Platformer.Gameplay;

namespace Platformer.Gameplay
{
        /// <summary>
    /// Fired when a bullet collides with an Enemy.
    /// </summary>
    /// <typeparam name="EnemyBullet"></typeparam>

    public class EnemyBulletTouch : MonoBehaviour
    {
        public EnemyController enemy;

        public Bullet bullet;
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();


        
       

    }
}