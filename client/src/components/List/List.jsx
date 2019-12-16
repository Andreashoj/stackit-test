import React, { useContext } from "react";
import Filtering from "./Filter";
import { UserContext } from "../../context/UserContext";

const List = ({ userType }) => {
  const { isAdmin } = useContext(UserContext);

  const filterTypes = [
    { id: 1, name: "Companies" },
    { id: 3, name: "Machines" },
    { id: 2, name: "Operators" }
  ];

  const userFilter = types => {
    return isAdmin ? types : types.filter(option => option.id !== 1);
  };

  const filteredTypes = userFilter(filterTypes);

  return (
    <>
      <Filtering type={filteredTypes} />
    </>
  );
};

export default List;
