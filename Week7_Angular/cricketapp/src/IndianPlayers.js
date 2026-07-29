import React from "react";

const IndianTeam = [
  "Sachin",
  "Dhoni",
  "Virat",
  "Rohit",
  "Yuvaraj",
  "Raina"
];

// Destructuring
export function OddPlayers({ IndianTeam }) {
  const [first, , third, , fifth] = IndianTeam;
  return (
    <div>
      <li>First : {first}</li>
      <li>Third : {third}</li>
      <li>Fifth : {fifth}</li>
    </div>
  );
}
export function EvenPlayers({ IndianTeam }) {
  const [, second, , fourth, , sixth] = IndianTeam;
  return (
    <div>
      <li>Second : {second}</li>
      <li>Fourth : {fourth}</li>
      <li>Sixth : {sixth}</li>
    </div>
  );
}

// Merge using spread operator
const T20Players = ["First Player", "Second Player", "Third Player"];
const RanjiTrophyPlayers = ["Fourth Player", "Fifth Player", "Sixth Player"];

export const IndianPlayers = [
  ...T20Players,
  ...RanjiTrophyPlayers
];

export function ListofIndianPlayers({ IndianPlayers }) {
  return (
    <div>
      {IndianPlayers.map((player, index) => (
        <li key={index}>Mr. {player}</li>
      ))}
    </div>
  );
}

export default IndianTeam;