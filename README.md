ProspectorSolitaire

An implementation of solitaire from "Introduction to Game Design, Prototyping, and Development Second Edition"
by Jeremy Gibson Bond

The game works by arranging the cards into a deck to be picked from and three inverted pyramids, where the top level of the
pyramids are revealed. You then take a card from the top of the deck and place them in a pile in the center to start.
The goal is to find a card that is either one higher or one lower in rank and click on them in order to put them on top
of the center pile. As more cards are taken from the pyramids, cards in lower levels will be uncovered. The goal of the game is to
completely empty all of the pyramids with the smallest amounts of cards removed from the deck. Additional points can be earned
by creating "runs" which are series' of moves where the player does not take any cards from the deck. The game detects when
there are no moves left and the deck pile is empty, ends the round and begins a new round. Enjoy!

To save time, the code was originally taken from the repo found at https://github.com/MRHALL1/Prospector-Solitaire. This repo
contains code from the first edition of the book, and thus has some items that have been deprecated and cause the game to not
function correctly. I modified the code using the up-to-date version to properly display the pips on the cards, changed the GUIText
elements to be Text elements, and added animations to the cards. When the cards are taken from the deck or a target card is
clicked, they are moved using an animation to the center pile.
