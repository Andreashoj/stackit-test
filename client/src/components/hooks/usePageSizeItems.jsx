import React, { useEffect, useState } from "react";

const UsePageSizeItems = () => {
  const [items, setItems] = useState();
  const element = document.querySelector(".List-wrapper");

  useEffect(() => {
    if (element != null) {
      return setItems(Math.floor((element.clientHeight - 140) / 70));
    }
  }, [element]);

  return items;
};

export default UsePageSizeItems;
