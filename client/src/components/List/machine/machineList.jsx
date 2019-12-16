import React, { useState, useEffect, useContext } from "react";
import machine from "../../../assets/jsons/machine.json";
import Pagination from "../../common/Pageination";
import { paginate } from "../../../utills/pagination/pagination";
import { useHistory } from "react-router-dom";
import ModalAdd from "../opeList/ModalAdd.jsx";
import UsePageSizeItems from "../../hooks/usePageSizeItems.jsx";
import { UserContext } from "../../../context/UserContext.jsx";
import useSearch from "../../hooks/useSearch.jsx";
import http from "../../../services/http.js";

const MachineList = ({ dashboard, searchNum }) => {
  let history = useHistory();
  const { isAdmin } = useContext(UserContext);
  const [machineTest, setMachineTest] = useState([]);
  const [modalData, setModalData] = useState();
  const [modalAdd, setModalAdd] = useState(false);
  const [count, setCount] = useState();
  const searchList = useSearch(searchNum, machineTest);
  const { token } = JSON.parse(sessionStorage.getItem("user"));
  const pageSize = dashboard !== undefined ? 5 : UsePageSizeItems();

  const [machineState, setState] = useState({
    machineList: machineTest,
    pageSize,
    count: count,
    currentPage: 1
  });

  useEffect(() => {
    http.get(`machines/companies/${10}`, token).then(data => {
      setMachineTest(data);
    });
  }, []);

  useEffect(() => {
    if (searchList.length !== 0) {
      setState(prevState => ({
        ...prevState,
        machineList: searchList
      }));
    } else {
      setState(prevState => ({
        ...prevState,
        machineList: machineTest,
        count: dashboard !== undefined ? 0 : machineTest.length
      }));
    }
  }, [searchNum, machineTest]);

  useEffect(() => {
    setState(prevState => ({
      ...prevState,
      pageSize: pageSize
    }));
  }, [pageSize]);

  //Handle the event and update the state
  const handlePageChange = page => {
    setState(prevState => ({
      ...prevState,
      currentPage: page
    }));
  };

  const machines = paginate(
    machineState.machineList,
    machineState.currentPage,
    machineState.pageSize
  );

  const handleRedirect = id => {
    history.push(`/machines/${id}`);
  };

  return (
    <section className="List-wrapper">
      <table className="listWrapper">
        <thead className="listHead">
          <tr>
            <th className="listTitle">Machine id</th>
            <th className="listTitle">Machine name</th>
          </tr>
        </thead>
        {machines.map(machine => (
          <tbody
            key={machine.id}
            className="listWrapper"
            onClick={() => handleRedirect(machine.id)}
          >
            <tr className="listBody">
              <td>{machine.id}</td>
              <td>{machine.name}</td>
            </tr>
          </tbody>
        ))}
      </table>
      {isAdmin ? (
        <div className="modal-add" onClick={() => setModalAdd(true)}>
          Add <span className="modal__add">+</span>
        </div>
      ) : null}
      {modalAdd ? (
        <ModalAdd
          state={machineState}
          setState={setState}
          data={modalData}
          show={modalAdd}
          setModal={setModalAdd}
        />
      ) : null}

      <Pagination
        itemsCount={machineState.count}
        pageSize={machineState.pageSize}
        onPageChange={handlePageChange}
        currentPage={machineState.currentPage}
      />
    </section>
  );
};

export default MachineList;
