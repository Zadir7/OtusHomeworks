﻿using System;
using UnityEngine;
using VContainer.Unity;

namespace ShootEmUp
{
    public sealed class CharacterFireController : IStartable, IDisposable
    {
        private readonly InputManager inputManager;
        private readonly BulletConfig bulletConfig;
        private readonly BulletSystem bulletSystem;
        private readonly WeaponComponent characterWeapon;

        public CharacterFireController(
            InputManager inputManager, 
            CharacterView characterView, 
            BulletConfig bulletConfig, 
            BulletSystem bulletSystem)
        {
            this.inputManager = inputManager;
            this.bulletConfig = bulletConfig;
            this.bulletSystem = bulletSystem;
            this.characterWeapon = characterView.GetComponent<WeaponComponent>();
        }
        
        public void Start()
        {
            this.inputManager.OnFireInput += FirePlayerProjectile;
        }

        public void Dispose()
        {
            this.inputManager.OnFireInput -= FirePlayerProjectile;
        }

        private void FirePlayerProjectile()
        {
            this.bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int)this.bulletConfig.physicsLayer,
                color = this.bulletConfig.color,
                damage = this.bulletConfig.damage,
                position = characterWeapon.Position,
                velocity = characterWeapon.Rotation * Vector3.up * this.bulletConfig.speed
            });
        }
    }
}