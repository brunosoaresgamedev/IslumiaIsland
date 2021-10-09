﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpriteCostumize : MonoBehaviour
{

    public int skinBulletNr;

    public Skins[] skinsClava, skinsShuriken, skinsDagger;

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {

        if (skinBulletNr > skinsClava.Length - 1) skinBulletNr = skinsClava.Length - 1;
        else if (skinBulletNr < 0) skinBulletNr = skinsClava.Length - 1;

        //   = GameManager.instance.WeaponLevel1;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        SkinChoice();


    }

    void SkinChoice()
    {
        if (spriteRenderer.sprite.name.Contains("ClavaT1+0") && GameManager.instance.WeaponType == 0)
        {
            string spriteName = spriteRenderer.sprite.name;
            spriteName = spriteName.Replace("ClavaT1+0_", "");
            int spriteNr = int.Parse(spriteName);

            spriteRenderer.sprite = skinsClava[skinBulletNr].sprites[spriteNr];
        }

        if (spriteRenderer.sprite.name.Contains("ClavaT1+0") && GameManager.instance.WeaponType == 1)
        {
            string spriteName = spriteRenderer.sprite.name;
            spriteName = spriteName.Replace("ClavaT1+0_", "");
            int spriteNr = int.Parse(spriteName);

            spriteRenderer.sprite = skinsClava[skinBulletNr].sprites[spriteNr];
        }
    }


    [System.Serializable]
    public struct Skins
    {
        public Sprite[] sprites;
    }

}
