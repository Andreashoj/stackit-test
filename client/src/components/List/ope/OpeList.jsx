import React, { useState } from "react";
import ope from "../../../assets/jsons/Ope.json";
import Pagination from "../../common/Pageination";
import { paginate } from "../../../utills/pagination/pagination";
import { useHistory } from "react-router-dom";
import Heading from "../../Heading/Heading";

const OpeList = props => {
  let history = useHistory();

  const [opeState, setOpeState] = useState({
    opeList: ope,
    pageSize: 6,
    count: ope.length,
    currentPage: 1
  });

  //Handle the event and update the state
  const handlePageChange = page => {
    setOpeState(prevState => ({
      ...prevState,
      currentPage: page
    }));
  };

  /*
    pageination for operators
  */

  const opes = paginate(
    opeState.opeList,
    opeState.currentPage,
    opeState.pageSize
  );

  const handleRedirect = id => {
    history.push(`/operators/${id}`);
  };

  return (
    <section className="List-wrapper">
      <div className="List-header"></div>
      <section className="List-body">
        <table className="">
          <thead>
            <th className="List-title">Operators</th>
            <th className="List-title">Machines</th>
          </thead>

          {opes.map(ope => (
            <tbody
              className="ListWrapper"
              onClick={() => handleRedirect(ope._id)}
            >
              <tr className="listBody" key={ope._id}>
                <td>{ope.name}</td>
                <td>{ope.machines.length}</td>
              </tr>
            </tbody>
          ))}
        </table>

        <Pagination
          itemsCount={opeState.count}
          pageSize={opeState.pageSize}
          onPageChange={handlePageChange}
          currentPage={opeState.currentPage}
        />
      </section>
    </section>
  );
};

export default OpeList;
