import React, { useState, useContext, useEffect } from "react";
import List from "../../components/List/List";
import Heading from "../../components/Heading/Heading";
import getMachines from "../../assets/jsons/machine.json";
import getOpes from "../../assets/jsons/Ope.json";
import getCompanies from "../../assets/jsons/companies.json";
import { UserContext } from "../../context/UserContext";

import http from "../../services/http";

const DashBoard = () => {
  const { user } = useContext(UserContext);

  const [ListItems, setListState] = useState({
    machines: [],
    opes: [],
    companies: []
  });

  useEffect(() => {
    setListState({
      machines: getMachines,
      opes: getOpes,
      companies: getCompanies
    });
  }, []);

  return (
    <div className="dashboard-wrapper">
      <Heading title={`${user.userType} - ${user.name}`} />
      <List items={ListItems} />
    </div>
  );
};

export default DashBoard;
