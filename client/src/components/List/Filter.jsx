import React, { useState, useContext } from "react";
import MachineList from "./machine/machineList";
import OpeList from "./opeList/OpeList";
import CompanyList from "./company/CompanyList";
import { UserContext } from "../../context/UserContext";

const Filtering = ({ type }) => {
  const { isAdmin } = useContext(UserContext);
  const [search, setSearch] = useState();

  const [option, setOption] = useState({
    optionType: ""
  });

  const handleChange = e => {
    setOption({
      optionType: e.target.value
    });
  };

  const handleSearch = e => {
    e.preventDefault();
    setSearch(e.target.value);
  };

  return (
    <>
      <div className="filterGroup">
        <form onSubmit={e => e.preventDefault()}>
          <select className="Filter-select" onChange={e => handleChange(e)}>
            {type.map(item => (
              <option key={item.id} value={item.name}>
                {item.name}
              </option>
            ))}
          </select>
          <input
            type="number"
            className="Filter-select"
            placeholder="Search by ID"
            onChange={e => handleSearch(e)}
            value={search}
          />
        </form>
      </div>
      {option.optionType === "Machines" ? (
        <MachineList dashboard={"dashboard"} searchNum={search} />
      ) : option.optionType === "Operators" ? (
        <OpeList dashboard={"dashboard"} searchNum={search} />
      ) : option.optionType === "Companies" ? (
        isAdmin ? (
          <CompanyList dashboard={"dashboard"} searchNum={search} />
        ) : null
      ) : (
        <MachineList dashboard={"dashboard"} searchNum={search} />
      )}
    </>
  );
};

export default Filtering;
