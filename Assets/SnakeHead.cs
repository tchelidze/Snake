using System.Collections.Generic;
using System.Linq;
using Assets;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    bool _eat;
    readonly List<Transform> _snakeBody = new List<Transform>();

    Vector2 _currentDirection = Vector2.right;
    GameObject _foodGameObject;

    public GameObject BodyItemPrefab;

    public Transform BorderBottom;
    public Transform BorderLeft;
    public Transform BorderRight;
    public Transform BorderTop;
    public GameObject FoodPrefab;

    void Start()
    {
        SpawnFood();
        InvokeRepeating("Move", 0.3f, 0.1f);
    }

    void Update()
    {
        //მარტო თავია დარჩენილი ?
        var isHeadOnly = !_snakeBody.Any();

        if (Input.GetKey(KeyCode.RightArrow)
            && (isHeadOnly || _currentDirection != Vector2.left))
            _currentDirection = Vector2.right;
        else if (
            Input.GetKey(KeyCode.LeftArrow)
            && (isHeadOnly || _currentDirection != Vector2.right))
            _currentDirection = Vector2.left;
        else if (
            Input.GetKey(KeyCode.DownArrow)
            && (isHeadOnly || _currentDirection != Vector2.up))
            _currentDirection = Vector2.down;
        else if (
            Input.GetKey(KeyCode.UpArrow)
            && (isHeadOnly || _currentDirection != Vector2.down))
            _currentDirection = Vector2.up;
    }

    void Move()
    {
        var headPreviousPosition = transform.position;
        transform.Translate(_currentDirection);
        if (_eat)
        {
            var bodyItem = Instantiate(BodyItemPrefab, headPreviousPosition, Quaternion.identity);
            _snakeBody.AddFirst(bodyItem.transform);
            _eat = false;
        }
        else if (_snakeBody.Any())
        {
            _snakeBody.Last().position = headPreviousPosition;
            _snakeBody.Move(_snakeBody.Count - 1, 0);
        }
    }

    static bool IsFood(Collider2D what)
    {
        return what.CompareTag("Food");
    }

    void SpawnFood()
    {
        _foodGameObject = Instantiate(
            FoodPrefab,
            GetNextFoodPosition(),
            Quaternion.identity);
    }

    Vector2 GetNextFoodPosition()
    {
        return RandomExtensions.RandomPosition(
            (int)BorderLeft.position.x + 1,
            (int)BorderRight.position.x - 1,
            (int)BorderBottom.position.y + 1,
            (int)BorderTop.position.y - 1,
            _snakeBody.Select(it => new Vector2((int)it.position.x, (int)it.position.y)).ToArray());
    }

    void OnTriggerEnter2D(Collider2D with)
    {
        if (IsFood(with))
        {
            _foodGameObject.transform.position = GetNextFoodPosition();
            _eat = true;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
    }
}