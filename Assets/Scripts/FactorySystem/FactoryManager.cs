using FactorySystem.Factory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


namespace FactorySystem
{
    public class FactoryManager
    {
        private static FactoryManager instance;
        public static FactoryManager Instance
        {
            get
            {
                if (instance == null)
                {
                    var ctor = typeof(FactoryManager).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new System.Type[0], null);

                    if (ctor == null)
                    {
                        throw new NullReferenceException("这个类必须有一个私有的无参的构造函数!!!");
                    }

                    instance = (FactoryManager)ctor.Invoke(null);
                }

                return instance;
            }
        }
        private FactoryManager() { }


        private AssetFactory mAssetFactory;
        private UIPanelFactory mUIPanelFactory;
        private CharacterFactory mCharacterFactory;
        private SpriteFactory mSpriteFactory;
        private ItemViewFactory mItemViewFactory;
        private ItemInfoFactory mItemInfoFactory;


        public AssetFactory GetAssetFactory
        {
            get
            {
                if (mAssetFactory  == null )
                {
                    mAssetFactory = new AssetFactory();
                }
                return mAssetFactory;
            }
        }
        public UIPanelFactory GetUIPanelFactory
        {
            get
            {
                if (mUIPanelFactory == null)
                {
                    mUIPanelFactory = new UIPanelFactory();
                }
                return mUIPanelFactory;
            }
        }
        public CharacterFactory GetCharacterFactory
        {
            get
            {
                if (mCharacterFactory == null)
                {
                    mCharacterFactory = new CharacterFactory();
                }
                return mCharacterFactory;
            }
        }
        public SpriteFactory GetSpriteFactory
        {
            get
            {
                if (mSpriteFactory == null)
                {
                    mSpriteFactory = new SpriteFactory();
                }
                return mSpriteFactory;
            }
        }
        public ItemViewFactory GetItemViewFactory
        {
            get
            {
                if (mItemViewFactory  == null)
                {
                    mItemViewFactory = new ItemViewFactory();
                }
                return mItemViewFactory;
            }
        }

        public ItemInfoFactory GetItemInfoFactory
        {
            get
            {
                if (mItemInfoFactory == null)
                {
                    mItemInfoFactory = new ItemInfoFactory();
                }
                return mItemInfoFactory;
            }
        }

    }
}