# Proc Balancer

Many games make use of programmed random occurrences (a.k.a. procs) for a variety of systems and effects. Sometimes though, the average experience of a player may vary way more than desired, causing a 'lucky' player to have much better results while an 'unlucky' one may fail a lot and get frustrated. This is particularly true when procs have a bigger impact on the end result of a game, defining who wins and loses.

The goal of this project is to adjust proc chances dynamically based on past results, steering them closely to the desired chance and creating a more similar and fair experience for every player. 

Some use cases may include:
- Adjusting drop rates so a player doesn't get too many rare drops in a row or doesn't go too long without getting one
- Making chances fair in competitive games so a player won't get too much of an advantage because of lucky rolls
- Creating consistent and precise results over a long sequence of tries

## Getting Started

The basic method used for balancing procs starts out with the same chance as the desired occurence chance and, as it rolls each proc, it will increase or reduce the current chance according to a balance ratio. The amount added or subtracted equals the desired chance multiplied by the ratio. A higher ratio will produce quicker and more noticeable results, whereas a lower ratio will produce sublter ones.

Included in the code there's a unity scene that allows you to test different chances, ratios and amount of tries, creating a graph and a log with information comparing the results with 'true random' ones.

![demo](https://gitlab.com/akashenen/proc-balancer/raw/master/demo.png)

## Authors

* [Akashenen](https://gitlab.com/akashenen/)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

