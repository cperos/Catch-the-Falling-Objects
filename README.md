# 🎮 **Unity Mini-Game: "Catch the Falling Objects"**

---

## **🌟 Introduction**
Catch the falling objects from a series of tubes. These objects include colorful gems, coins, and other valuables. However, you must steer clear of the bombs. Using a data-driven approach, this game is scalable and easy to modify. The AppManager initiates the game and spawns a LevelManager, Player Manager, and Timer Manager upon start.

## **🕹️ How to Play**
1. **Objective:** Catch falling objects from the tubes at the top of the screen using a cart positioned at the bottom.
2. **Controls:** Use left and right arrow keys (or 'a' and 'd' keys in the WASD setup) to move the cart.
3. **Avoid:** Bombs which decrease your health.
4. **Collect:** Coins and gems of varying values. Hearts restore a small amount of health.
5. **End Condition:** The game ends when the timer runs out. The player can restart the game.

## **🎉 Game Features**
- **Timer**: Visualized as a bomb fuse for immersion.
- **Loot Types**: Green coins, blue coins, yellow coins, purple gems, and diamond gems.
- **Special Effects**: Bomb animations play when the bomb explodes.

## **🧠 Programming Theory**
- **Data-Driven Design**: By leveraging Unity's ScriptableObjects, the game abstracts data from behavior. This promotes flexibility in design and ease of scalability.
- **Managers**: AppManager controls the game's lifecycle, while the LevelManager, PlayerManager, and TimerManager handle their respective domains.

## **⚙️ Future Considerations and Enhancements**
1. **More Loot Types**: Introduce more objects with varying effects, such as a clock to slow time with accompanying visual effects.
2. **Multiplayer Mode**: With the foundational elements in place, extend the game for multiple players.
3. **Enhanced Levels**: With the data-driven approach, create diversified levels by tweaking the ScriptableObjects.

## **📂 Repository Structure**
- **Scriptable Objects**:
  - `LootSO`: Contains data for different loot types.
  - `PipeSO`: Contains data for different spawner pipes.
  - `LevelDataSO`: Contains information for different levels.
  - `PlayerSO`: Contains player-related data.

- **Managers**:
  - `AppManager`: Initiates the game and controls its lifecycle.
  - `PlayerManager`: Manages the player's properties and behavior.
  - `LevelManager`: Manages and initializes game levels.
  - `TimerManager`: Manages the game timer.

---

## **❗ Assumptions and Edge Cases**
1. **Assumptions**: The game is based on a 2D framework, ensuring that scaling, positions, and movements operate in two-dimensional space.
2. **Handled Edge Cases**: 
   - Player movement restricted within the screen bounds.
   - Object spawning has been randomized to ensure unpredictability.
3. **Yet to Handle**:
   - Multiplayer game mechanics and score comparison.

## **💡 More Ideas**
- **New Power-Ups**: Introducing power-ups like shields, multipliers, and magnetism to attract coins.
- **Dynamic Difficulty**: Increase the falling speed or introduce more bombs as the player's score increases.
- **Design Enhancements**: To implement these, the current design can be expanded by adding more ScriptableObjects and enhancing the managers.

## 🗓️ **Project Timeline & Efficiency**

Working within a limited timeframe, this project was kickstarted on a Friday noon and completed by Sunday, 9 pm. My confidence in accurately estimating task durations allowed for this swift execution.

## **🔚 Concluding Notes**
This game provides a fun and challenging experience by integrating traditional game mechanics with a unique data-driven approach. It demonstrates proficiency in Unity development and an understanding of scalable game design.

For the complete game source and assets, please visit the provided GitHub repository. Feedback and contributions are welcome. 

**Best of luck and happy gaming!** 🎉

