// import 'dart:async';
// import 'dart:math';

// import 'package:flutter/material.dart';

// //главный класс игры
// class HomePage extends StatefulWidget {
//   const HomePage({Key? key});

//   @override
//   State<HomePage> createState() => _HomePageState();
// }

// // объявление направлений (вверх, вниз, влево, вправо)
// enum Direction {
//   up,
//   down,
//   left,
//   right,
// }

// class Food{
//    late int position;

//   void generateFood(List<int> borderList, int row, int column) {
//     position = Random().nextInt(row * column);
//     if (borderList.contains(position)) {
//       generateFood(borderList, row, column);
//     }
//   }

// }

// class _HomePageState extends State<HomePage> {
//   int row = 20, column = 20;
//   List<int> borderList = [];
//   List<int> shakePosition = [];
//   int shakeHead = 0;
//   int score = 0;
//   late Direction direction;
//   late int foodPosition;

//   @override
//   void initState() {
//     startGame();
//     super.initState();
//   }

// //функция начала игры
//   void startGame() {
//     makeBorder();
//     generateFood();
//     direction = Direction.right;
//     shakePosition = [45, 44, 43];
//     shakeHead = shakePosition.first;
//     Timer.periodic(const Duration(milliseconds: 300), (timer) {
//       updateShake();
//       if (checkCollision()) {
//         timer.cancel();
//         showGameOver();
//       }
//     });
//   }

//   void showGameOver() {
//     showDialog(
//       context: context,
//       barrierDismissible: false,
//       builder: (context) {
//         return AlertDialog(
//           title: const Text("Game Over"),
//           content: const Text("Your snake is RIP"),
//           actions: [
//             TextButton(
//               onPressed: () {
//                 Navigator.of(context).pop();
//                 startGame();
//               },
//               child: const Text("Restart"),
//             ),
//           ],
//         );
//       },
//     );
//   }

//   bool checkCollision() {
//     // края
//     if (borderList.contains(shakeHead)) return true;
//     //себя
//     if (shakePosition.sublist(1).contains(shakeHead)) return true;
//     return false;
//   }

//   void generateFood() {
//     foodPosition = Random().nextInt(row * column);
//     if (borderList.contains(foodPosition)) {
//       generateFood();
//     }
//   }

//   void updateShake() {
//     setState(() {
//       switch (direction) {
//         case Direction.up:
//           shakePosition.insert(0, shakeHead - column);
//           break;
//         case Direction.down:
//           shakePosition.insert(0, shakeHead + column);
//           break;
//         case Direction.right:
//           shakePosition.insert(0, shakeHead + 1);
//           break;
//         case Direction.left:
//           shakePosition.insert(0, shakeHead - 1);
//           break;
//       }
//     });

//     if (shakeHead == foodPosition) {
//       score++;
//       generateFood();
//     } else {
//       shakePosition.removeLast();
//     }

//     shakeHead = shakePosition.first;
//   }

//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//       body: Column(
//         children: [
//           Expanded(child: _buildGameView()),
//           _buildGameControls(),
//         ],
//       ),
//     );
//   }

//   Widget _buildGameView() {
//     return GridView.builder(
//       gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(crossAxisCount: column),
//       itemBuilder: (context, index) {
//         return Container(
//           margin: const EdgeInsets.all(1),
//           decoration: BoxDecoration(
//             borderRadius: BorderRadius.circular(8),
//             color: fillBoxColor(index),
//           ),
//         );
//       },
//       itemCount: row * column,
//     );
//   }

//   Color fillBoxColor(int index) {
//     if (shakePosition.contains(index)) {
//       return Color.fromARGB(255, 13, 150, 40);
//     } else if (borderList.contains(index)) {
//       return Color.fromARGB(255, 111, 195, 114);
//     } else if (index == foodPosition) {
//       return Color.fromARGB(255, 181, 66, 9);
//     } else {
//       return Color.fromARGB(255, 224, 208, 193);
//     }
//   }

//   void makeBorder() {
//     for (int i = 0; i < row; i++) {
//       borderList.add(i); // top border
//       borderList.add(i * column); // left border
//       borderList.add(i * column + column - 1); // right border
//       borderList.add((row - 1) * column + i); // bottom border
//     }
//   }

//  Widget _buildGameControls() {
//       return Container(
//         padding: const EdgeInsets.all(20),
//         width: double.infinity,
//         child: Column(
//           mainAxisAlignment: MainAxisAlignment.center,
//           children: [
//             Text("Score: $score"),
//             IconButton(
//               onPressed: (){
//                 if(direction!=Direction.down) direction = Direction.up;
//               },
//               icon: const Icon(Icons.arrow_circle_up),
//               iconSize: 100,
//               ),
//               Row(
//                 mainAxisAlignment: MainAxisAlignment.center,
//                 children: [
//                   IconButton(
//                   onPressed: (){

//                 if(direction!=Direction.right) direction = Direction.left;
//                   },
//                   icon: const Icon(Icons.arrow_circle_left_outlined),
//                   iconSize: 100,
//                   ),
//                   const SizedBox(width: 100),
//                   IconButton(
//                   onPressed: (){

//                 if(direction!=Direction.left) direction = Direction.right;
//                   },
//                   icon: const Icon(Icons.arrow_circle_right_outlined),
//                   iconSize: 100,
//                   ),
//                 ],
//               ),
//               IconButton(
//               onPressed: (){

//                 if(direction!=Direction.up) direction = Direction.down;
//               },
//               icon: const Icon(Icons.arrow_circle_down_outlined),
//               iconSize: 100,
//               ),
//           ],
//         )
//       );
//     }
//  }

// // import 'dart:async';
// // import 'dart:math';
// // import 'package:flutter/material.dart';

// // class SnakeGame extends StatefulWidget {
// //   const SnakeGame({Key? key});

// //   @override
// //   State<SnakeGame> createState() => _SnakeGameState();
// // }

// // class _SnakeGameState extends State<SnakeGame> {
// //   late Snake snake;
// //   late Food food;
// //   int score = 0;
// //   late Direction direction ;

// //   @override
// //   void initState() {
// //     super.initState();
// //      // Передаем функцию обратного вызова updateState в конструктор Snake
// //     snake = Snake(updateState);
// //     direction = Direction.right;
// //     food = Food();
// //     snake.startGame();
// //   }
// //  void updateState() {
// //     setState(() {
// //        snake.move(direction); // Вызываем метод движения змейки с новым направлением
// //     });
// //   }

// //   void restartGame() {
// //     setState(() {
// //       score = 0;
// //       snake.startGame();
// //     });
// //   }
// // @override
// // Widget build(BuildContext context) {
// //   return Scaffold(
// //     body: Column(
// //       children: [
// //         Expanded(
// //           child: GridView.builder(
// //             gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(crossAxisCount: snake.column),
// //             itemBuilder: (context, index) {
// //               return Container(
// //                 margin: const EdgeInsets.all(1),
// //                 decoration: BoxDecoration(
// //                   borderRadius: BorderRadius.circular(8),
// //                   color: snake.fillBoxColor(index),
// //                 ),
// //               );
// //             },
// //             itemCount: snake.row * snake.column,
// //           ),
// //         ),
// //         _buildGameControls(), // Вставляем сюда
// //       ],
// //     ),
// //   );
// // }

// // Widget _buildGameControls() {
// //   return Column(
// //     mainAxisAlignment: MainAxisAlignment.center,
// //     children: [
// //       Text('Score: $score'),
// //       ElevatedButton(
// //         onPressed: restartGame,
// //         child: Text('Restart'),
// //       ),
// //       SizedBox(height: 16),
// //       Container(
// //         padding: const EdgeInsets.all(20),
// //         width: double.infinity,
// //         child: Column(
// //           mainAxisAlignment: MainAxisAlignment.center,
// //           children: [
// //             Text("Score: $score"),
// //             IconButton(
// //               onPressed: () {
// //                 setState(() {
// //                   if (direction != Direction.down) direction = Direction.up;
// //                 });
// //               },
// //               icon: const Icon(Icons.arrow_circle_up),
// //               iconSize: 100,
// //             ),
// //             Row(
// //               mainAxisAlignment: MainAxisAlignment.center,
// //               children: [
// //                 IconButton(
// //                   onPressed: () {
// //                     setState(() {
// //                       if (direction != Direction.right) direction = Direction.left;
// //                     });
// //                   },
// //                   icon: const Icon(Icons.arrow_circle_left_outlined),
// //                   iconSize: 100,
// //                 ),
// //                 const SizedBox(width: 100),
// //                 IconButton(
// //                   onPressed: () {
// //                     setState(() {
// //                       if (direction != Direction.left) direction = Direction.right;
// //                     });
// //                   },
// //                   icon: const Icon(Icons.arrow_circle_right_outlined),
// //                   iconSize: 100,
// //                 ),
// //               ],
// //             ),
// //             IconButton(
// //               onPressed: () {
// //                 setState(() {
// //                   if (direction != Direction.up) direction = Direction.down;
// //                 });
// //               },
// //               icon: const Icon(Icons.arrow_circle_down_outlined),
// //               iconSize: 100,
// //             ),
// //           ],
// //         ),
// //       ),
// //     ],
// //   );
// // }

// // }

// // enum Direction {
// //   up,
// //   down,
// //   left,
// //   right,
// // }

// // class Snake {
// //   int row = 20;
// //   int column = 20;
// //   List<int> borderList = [];
// //   List<int> shakePosition = [];
// //   int shakeHead = 0;
// //   late Direction direction;
// //    late int foodPosition;

// //   void startGame() {
// //     makeBorder();
// //     generateFood();
// //     direction = Direction.right;
// //     shakePosition = [45, 44, 43];
// //     shakeHead = shakePosition.first;
// //     Timer.periodic(const Duration(milliseconds: 300), (timer) {
// //       updateSnake();
// //       if (checkCollision()) {
// //         timer.cancel();
// //         //showGameOver();
// //       }
// //     });
// //   }

// //  void move(Direction direction) {

// //       switch (direction) {
// //         case Direction.up:
// //           shakePosition.insert(0, shakeHead - column);
// //           break;
// //         case Direction.down:
// //           shakePosition.insert(0, shakeHead + column);
// //           break;
// //         case Direction.right:
// //           shakePosition.insert(0, shakeHead + 1);
// //           break;
// //         case Direction.left:
// //           shakePosition.insert(0, shakeHead - 1);
// //           break;
// //       }

// //   }

// //   void makeBorder() {
// //   for (int i = 0; i < row; i++) {
// //       borderList.add(i); // top border
// //       borderList.add(i * column); // left border
// //       borderList.add(i * column + column - 1); // right border
// //       borderList.add((row - 1) * column + i); // bottom border
// //     }
// //  }

// //   void generateFood() {
// //     foodPosition = Random().nextInt(row * column);
// //     if (borderList.contains(foodPosition)) {
// //       generateFood();
// //     }
// //   }

// //   bool checkCollision() {
// //    if (borderList.contains(shakeHead)) return true;
// //     //себя
// //     if (shakePosition.sublist(1).contains(shakeHead)) return true;
// //     return false;
// //   }
// // late VoidCallback updateState;

// //   Snake(this.updateState);

// //   void updateSnake() {
// //       updateState(); // Обновляем состояние игры
// //   int nextPosition;
// //   switch (direction) {
// //     case Direction.up:
// //       nextPosition = shakeHead - column;
// //       break;
// //     case Direction.down:
// //       nextPosition = shakeHead + column;
// //       break;
// //     case Direction.right:
// //       nextPosition = shakeHead + 1;
// //       break;
// //     case Direction.left:
// //       nextPosition = shakeHead - 1;
// //       break;
// //   }
// //   if (nextPosition == foodPosition) {
// //     // Если следующая позиция является позицией еды, увеличиваем счет и генерируем новую еду
// //    // score++;
// //     generateFood();
// //   } else {
// //     // Удаляем хвост змеи только в случае, если не съели еду
// //     shakePosition.removeLast();
// //   }
// //   shakePosition.insert(0, nextPosition); // Вставляем новую позицию головы змеи
// //   shakeHead = nextPosition; // Обновляем позицию головы

// //   }

// //   Color fillBoxColor(int index) {
// // if (shakePosition.contains(index)) {
// //       return Color.fromARGB(255, 94, 13, 114);
// //     } else if (borderList.contains(index)) {
// //       return Color.fromARGB(255, 111, 195, 114);
// //     } else if (index == foodPosition) {
// //       return Color.fromARGB(255, 181, 66, 9);
// //     } else {
// //       return Color.fromARGB(255, 128, 124, 120);
// //     }
// //   }
// // }

// // class Food {
// //   late int position;

// //   void generateFood(List<int> borderList, int row, int column) {
// //     position = Random().nextInt(row * column);
// //     if (borderList.contains(position)) {
// //       generateFood(borderList, row, column);
// //     }
// //   }
// // }

import 'dart:async';
import 'dart:math';
import 'package:flutter/material.dart';

class HomePage extends StatefulWidget {
  const HomePage({
    Key? key,
  });

  @override
  State<HomePage> createState() => _HomePageState();
}

enum Direction {
  up,
  down,
  left,
  right,
}

class _HomePageState extends State<HomePage> {
  int row = 20, column = 20;
  List<int> borderList = [];
  List<int> shakePosition = [];
  int shakeHead = 0;
  int score = 0;
  late Direction direction;
  late Food food = Food();

  @override
  void initState() {
    super.initState();
    //super.initState();
    // food = Food();
    startGame();
  }

  void startGame() {
    makeBorder();
    food.generateFood(row, column);
    direction = Direction.right;
    shakePosition = [45, 44, 43];
    shakeHead = shakePosition.first;
    Timer.periodic(const Duration(milliseconds: 300), (timer) {
      updateShake();
      if (checkCollision()) {
        timer.cancel();
        score = 0;
        showGameOver();
      }
    });
  }

  void showGameOver() {
    showDialog(
      context: context,
      barrierDismissible: false,
      builder: (context) {
        return AlertDialog(
          title: const Text("Game Over"),
          content: const Text("Your snake is RIP"),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
                startGame();
              },
              child: const Text("Restart"),
            ),
          ],
        );
      },
    );
  }

  bool checkCollision() {
    // края
    if (borderList.contains(shakeHead)) return true;
    //себя
    if (shakePosition.sublist(1).contains(shakeHead)) return true;
    return false;
  }

  void updateShake() {
    setState(() {
      switch (direction) {
        case Direction.up:
          shakePosition.insert(0, shakeHead - column);
          break;
        case Direction.down:
          shakePosition.insert(0, shakeHead + column);
          break;
        case Direction.right:
          shakePosition.insert(0, shakeHead + 1);
          break;
        case Direction.left:
          shakePosition.insert(0, shakeHead - 1);
          break;
      }
    });

    if (shakeHead == food.foodPosition) {
      setState(() {
        score++;
        food.generateFood(row, column);
      });
    } else {
      shakePosition.removeLast();
    }

    shakeHead = shakePosition.first;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        children: [
          Expanded(child: _buildGameView()),
          _buildGameControls(),
        ],
      ),
    );
  }

  Widget _buildGameView() {
    return GridView.builder(
      gridDelegate:
          SliverGridDelegateWithFixedCrossAxisCount(crossAxisCount: column),
      itemBuilder: (context, index) {
        return Container(
          margin: const EdgeInsets.all(1),
          decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(8),
            color: fillBoxColor(index),
          ),
        );
      },
      itemCount: row * column,
    );
  }

  // установка цвета для элементов в игре
  Color fillBoxColor(int index) {
    //установка цвета для змейки
    if (shakePosition.contains(index)) {
      return Color.fromARGB(255, 13, 150, 40);
      //границы игрового поля
    } else if (borderList.contains(index)) {
      return Color.fromARGB(255, 111, 195, 114);
      //цвет еды
    } else if (index == food.foodPosition) {
      return Color.fromARGB(255, 181, 66, 9);
    } else {
      //цвет игрового поля
      return Color.fromARGB(255, 224, 208, 193);
    }
  }

//создаем границы поля (строки, столбцы)
  void makeBorder() {
    for (int i = 0; i < row; i++) {
      borderList.add(i); //верхняя границы
      borderList.add(i * column); // лева границв
      borderList.add(i * column + column - 1); // правая граница
      borderList.add((row - 1) * column + i); // нижняя граница
    }
  }

  Widget _buildGameControls() {
    return Container(
        padding: const EdgeInsets.all(20),
        width: double.infinity,
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text("Score: $score"),
            IconButton(
              onPressed: () {
                if (direction != Direction.down) direction = Direction.up;
              },
              icon: const Icon(Icons.arrow_circle_up),
              iconSize: 100,
            ),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                IconButton(
                  onPressed: () {
                    if (direction != Direction.right)
                      direction = Direction.left;
                  },
                  icon: const Icon(Icons.arrow_circle_left_outlined),
                  iconSize: 100,
                ),
                const SizedBox(width: 100),
                IconButton(
                  onPressed: () {
                    if (direction != Direction.left)
                      direction = Direction.right;
                  },
                  icon: const Icon(Icons.arrow_circle_right_outlined),
                  iconSize: 100,
                ),
              ],
            ),
            IconButton(
              onPressed: () {
                if (direction != Direction.up) direction = Direction.down;
              },
              icon: const Icon(Icons.arrow_circle_down_outlined),
              iconSize: 100,
            ),
          ],
        ));
  }
}

//класс для Еды на поле (foodPosition- позиция еды borderList- поле)
class Food {
  late int foodPosition;
  List<int> borderList = [];

//генерация еды в рандомном месте на поле (row - строки coulmn- колонки)
  void generateFood(int row, int column) {
    //рандомное расположение
    foodPosition = Random().nextInt(row * column);
    if (borderList.contains(foodPosition)) {
      generateFood(row, column);
    } else {
      foodPosition = Random().nextInt(row * column);
    }
  }
}
