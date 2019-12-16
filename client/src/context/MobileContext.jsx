import React, {useState, createContext, useEffect } from "react";
import useWindowWidth from "../components/hooks/useWindowWidth";

export const MobileContext = createContext();

const MobileContextProvider = props => {
  const [isMobile, setIsMobile] = useState();
  const width = useWindowWidth();

  useEffect(() => {
    setIsMobile(width);
  },[isMobile, width]);

  return (
    <MobileContext.Provider value={{ isMobile }}>
      {props.children}
    </MobileContext.Provider>
  );
};

export default MobileContextProvider;
