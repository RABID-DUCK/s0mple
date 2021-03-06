using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static gameManager manager;
    public static PrefabStorage PrefabStorage;
    float roadLineCenterY;
    int availableLines = manager.lines + 1;


    public void SpawnObjects(float roadLineCenterY)
    {
        this.roadLineCenterY = roadLineCenterY; // Сохраняем на время выполнения чтобы не пробрасывать из метода в метод
        LoopThroughtLines(); // обходим все дорожные полосы
    }
    private void LoopThroughtLines()
    {
        int total = Random.Range(0, availableLines); // сколько препятствий нужно на этом сегменте
        int needed = total; // столько препятствий ещё осталось
        for (int i = 0; i < manager.lines; i++)
        {
            if (needed == 0) break; // ни одного препятствия больше не нужно(было)
            else if (!TrySpawnAtLine(i, needed, total)) // запрашиваем создание препятствия
                continue; // препятствие не выпало - переходим к следующей полосе
            needed--; // иначе уменьшаем количество препятствий которое ещё нужно
        }
    }

    private bool TrySpawnAtLine(int lineInd, int needed, int total)
    {
        var chance = needed / (float)(manager.lines - lineInd);
        if (chance < 1 && Random.Range(0, 1f) > chance) // был шанс от 0 до 1
            return false; // им не воспользовались
        var x = manager.roadLinesCentersX[lineInd]; // узнаём середину этой дорожной полосы
        var prefab = PrefabStorage.GetRandomPrefab(); // получаем префаб случайного препятствия
        CreateObj(x, prefab);
        return true;
    }

    private void CreateObj(float positionX, GameObject prefab)
    {
        // позднее здесь будет разброс по высоте
        var objPosition = new Vector3(positionX, roadLineCenterY);
        Object.Instantiate(prefab, objPosition, Quaternion.identity);
    }
}
