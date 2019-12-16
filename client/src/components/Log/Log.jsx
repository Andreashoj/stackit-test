import React, { useEffect, useState } from "react";
import ErrorLog from "./ErrorLog";
import SuccessLog from "./SuccessLog";

const Log = () => {
  const [isSuccess, setIsSuccess] = useState([]);
  const [isError, setIsError] = useState([]);

  const logData = [
    {
      id: 231,
      message: "Processed material to the next step....",
      isError: false
    },
    {
      id: 230,
      message: "Processed material to the next step....",
      isError: false
    },
    {
      id: 129,
      message: "Error in setup, missing materials..",
      isError: true
    },
    {
      id: 122,
      message: "Error in setup, missing materials..",
      isError: false
    }
  ];

  useEffect(() => {
    setIsSuccess(
      logData.filter(item => {
        if (!item.isError) {
          return item;
        } else {
          setIsError([item]);
          return null;
        }
      })
    );
  }, []);

  return (
    <div className="machine-log">
      <h3>Errors</h3>
      <ErrorLog error={isError} />
      <h3>Log</h3>
      <SuccessLog success={isSuccess} />
    </div>
  );
};

export default Log;
