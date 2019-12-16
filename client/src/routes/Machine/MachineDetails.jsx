import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import Heading from "../../components/Heading/Heading";
import Log from "../../components/Log/Log";
import CurrentStack from "./CurrentStack";
import CurrentJob from "./CurrentJob";
import StackQuery from "./StackQuery";
import data from "../../assets/jsons/machine";
import http from "../../services/http";

const MachineDetails = () => {
  let { id } = useParams();
  const [machineData, setMachineData] = useState(data);

  useEffect(() => {
    const paramId = Number(id);
    const machine = machineData.filter(machine => machine._id === paramId);
    setMachineData(machine);
  }, []);

  return (
    <div className="machine-details">
      <Heading title={"Machine"} desc={"#" + id} />
      <CurrentStack machine={machineData} />
      <CurrentJob machine={machineData} />
      <StackQuery machine={machineData} />
      <Log />
    </div>
  );
};

export default MachineDetails;
