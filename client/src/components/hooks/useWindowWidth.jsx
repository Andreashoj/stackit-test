import { useEffect, useState } from "react";

const useWindowWidth = () => {
  const [browserWidth, setBrowserWidth] = useState(window.innerWidth);

  useEffect(() => {
    const handleResize = () => setBrowserWidth(window.innerWidth);
    window.addEventListener("resize", handleResize);
    return () => {
      window.removeEventListener("resize", handleResize);
    };
  }, []);

  return browserWidth < 1024 ? true : false;
};

export default useWindowWidth;
