import React, { useEffect, useState, useContext } from "react";
import { UserContext } from "../../context/UserContext";
import http from "../../services/http";

const CurrentStack = ({ machine }) => {
  const { user, token } = useContext(UserContext);
  const [upTime, setUptime] = useState();
  const [progress, setProgress] = useState();
  const [overtime, setOvertime] = useState(false);
  const { id } = machine;
  const currentStack = http.get("");

  const handleUptime = max => {
    const min = max * 60;
    const ranNum = Math.ceil(Math.floor(Math.random() * Math.floor(min + 35)));
    return ranNum;
  };

  useEffect(() => {
    const estTime = currentStack.estTime * 60;
    const uptime = handleUptime(currentStack.estTime);

    uptime > 60
      ? setUptime(Math.round((uptime / 60) * 10) / 10 + " hr")
      : setUptime(uptime + " min");

    const newProgress = (uptime * 100) / estTime;
    setProgress(Math.round(newProgress * 10) / 10);

    uptime > estTime ? setOvertime(true) : setOvertime(false);
  }, [currentStack]);

  const statusCode = () => {
    if (!overtime) {
      return <div className="current-stack__overtime positive"></div>;
    } else {
      return <div className="current-stack__overtime negative"></div>;
    }
  };

  return (
    <div className="current-stack">
      <table>
        <thead>
          <tr>
            <th>Current Stack</th>
            <th>Job Id</th>
            <th>Est. Time</th>
            <th>Uptime</th>
            <th>Progress</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>Stack 1</td>
            <td>Current job 2</td>
            <td>2 hr</td>
            <td>5 </td>
            <td>10 %</td>
            <td></td>
          </tr>
        </tbody>
      </table>
    </div>
  );
};

export default CurrentStack;

//<td>Stack {id}</td>
//<td>Current job {currentStack.jobs[0].id}</td>
//<td>{currentStack.estTime} hr</td>
//<td>{upTime} </td>
//<td>{progress} %</td>
//<td>{statusCode()}</td>
