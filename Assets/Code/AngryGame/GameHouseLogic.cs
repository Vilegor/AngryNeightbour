using System;
using System.Collections.Generic;
using Code.AngryGame.Data;
using Code.ServerLogic.Data;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.AngryGame
{
    public delegate void OnHouseClickHandler(GameHouseLogic houseObj);
    public class GameHouseLogic : MonoBehaviour
    {
        [Header("UI Settings")]
        public SpriteRenderer houseSpriteRenderer;
        public TextMeshPro levelText;
        public TextMeshPro hitText;

        // initial data
        private int _gridPosIndex;
        private int _startLevel;
        private GameHouseSkinType _skinType;
        private List<NeighbourData> _neighbourList;
        private bool _isPlayersHouse;

        // current state
        private int _currentLevel;
        private int _visualState; // stub

        // internal
        private List<OnHouseClickHandler> _clickHandlers = new List<OnHouseClickHandler>();
        private Animator _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();

            // test
            Setup(0, 5, GameHouseSkinType.Farm, new List<NeighbourData>());
        }

        public void Setup(int gridPosIndex, int startLevel, GameHouseSkinType skinType, List<NeighbourData> neighbourList, bool isPlayersHouse = false)
        {
            _gridPosIndex = gridPosIndex;
            _startLevel = startLevel;
            _neighbourList = neighbourList;
            _isPlayersHouse = isPlayersHouse;

            SetCurrentLevel(startLevel);
            SetHouseSkin(skinType);
        }

        private void SetHouseSkin(GameHouseSkinType skinType)
        {
            _skinType = skinType;
            Sprite newHouseSprite;

            switch (skinType)
            {
                case GameHouseSkinType.Farm:
                    newHouseSprite = Resources.Load<Sprite>("Houses/farm_house");
                    break;
                case GameHouseSkinType.Diagonal:
                    newHouseSprite = Resources.Load<Sprite>("Houses/diagonal_house");
                    break;
                case GameHouseSkinType.Love:
                    newHouseSprite = Resources.Load<Sprite>("Houses/love_house");
                    break;
                case GameHouseSkinType.Rusty:
                    newHouseSprite = Resources.Load<Sprite>("Houses/rusty_house");
                    break;
                case GameHouseSkinType.Modern:
                    newHouseSprite = Resources.Load<Sprite>("Houses/modern_house");
                    break;
                case GameHouseSkinType.High:
                    newHouseSprite = Resources.Load<Sprite>("Houses/high_house");
                    break;
                default:
                    newHouseSprite = Resources.Load<Sprite>("Houses/modern_house");
                    break;
            }

            houseSpriteRenderer.sprite = newHouseSprite;
        }

        private void SetCurrentLevel(int newHouseLevel)
        {
            _currentLevel = newHouseLevel;
            levelText.text = newHouseLevel.ToString();
        }

        private void SetPlayerHouseState(bool isPlayersHouse)
        {
            if (isPlayersHouse)
            {
                houseSpriteRenderer.color = new Color(105, 215, 255);    // highlight with light blue color
            }
            else
            {
                houseSpriteRenderer.color = Color.white;
            }
        }

        public void ApplyLevelUpdateWithAnimations(int newHouseLevel)
        {
            if (newHouseLevel == _currentLevel) return;

            int prevLevel = _currentLevel;
            _currentLevel = newHouseLevel > 0 ? newHouseLevel : 0;

            if (prevLevel < newHouseLevel)
            {
                // increase
                // green color: (25, 217, 0)
                hitText.text = $"+{(newHouseLevel - prevLevel)}";
                _animator.Play("LevelUpAnim");
            }
            else
            {
                // decrease
                // red color: (221, 66, 34)
                hitText.text = $"{(newHouseLevel - prevLevel)}";

                if (newHouseLevel <= 0)
                {
                    _animator.Play("DefeatedAnim");
                }
                else
                {
                    _animator.Play("LevelDownAnim");
                }
            }
        }

        private void OnChangeLevelTextAnimEvent()    // triggered from LevelUp and LevelDown animations
        {
            SetCurrentLevel(_currentLevel);
        }

        private void OnSetDefeatedLevelTextAnimEvent()    // triggered from LevelUp and LevelDown animations
        {
            SetCurrentLevel(0);
            levelText.text = "X_X";
        }

        public void AddOnClickListener(OnHouseClickHandler handler)
        {
            _clickHandlers.Add(handler);
        }

        private void OnMouseDown()
        {
            Debug.Log($"House #{_gridPosIndex} was clicked");
            foreach (var handler in _clickHandlers)
            {
                handler(this);
            }

            // test
            int levelDiff = Random.Range(-2, 1);
            ApplyLevelUpdateWithAnimations(_currentLevel + levelDiff);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
