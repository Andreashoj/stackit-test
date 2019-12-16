import React, { useState } from "react";

const useSearch = (searchNum, arr) => {
  // Først tager vi længden på inputtet
  // Herefter lave vi en funktion som tager et id, funktionen returner ID'et på
  // vores item, men den trimmer det ned så det passer med hvor mange tal der
  // er blevet tastet i inputtet
  // I vores filter laver vi et nyt array, hvor vi benytter os af trim funktionen
  // det der er essentielt sker er at vi sammenligner vores trimmede id med vores search
  // input. Så søger vi på 333, trimmer vi alle ide'erne ned til 3 tal og hvis de 3
  // tal matcher, bliver det godkendt i vores filter conditional
  if (arr !== undefined) {
    const length = searchNum ? searchNum.length : null;
    const trim = id => {
      return Number(id.toString().slice(0, length));
    };
    return arr.filter(item => trim(item.id) === Number(searchNum));
  } else {
    return [];
  }
};

export default useSearch;
