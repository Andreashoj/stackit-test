import React, { useState, useContext, useEffect } from "react";
import ope from "../../../assets/jsons/Ope.json";
import Pagination from "../../common/Pageination";
import { paginate } from "../../../utills/pagination/pagination";
import { useHistory } from "react-router-dom";
import Modal from "./Modal.jsx";
import ModalAdd from "./ModalAdd.jsx";
import edit_icon from "../../../assets/icons/edit.svg";
import delete_icon from "../../../assets/icons/delete.svg";
import { UserContext } from "../../../context/UserContext.jsx";
import UsePageSizeItems from "../../hooks/usePageSizeItems.jsx";
import useSearch from "../../hooks/useSearch.jsx";

const OpeList = ({ dashboard, searchNum }) => {
  let history = useHistory();

  const { user, isAdmin } = useContext(UserContext);

  const [modal, setModal] = useState(false);
  const [modalData, setModalData] = useState();
  const [modalAdd, setModalAdd] = useState(false);
  const searchList = useSearch(searchNum, ope);

  let itemCount = dashboard !== undefined ? 5 : UsePageSizeItems();
  let count = dashboard !== undefined ? Array.from(ope[1]) : ope.length;
  const [opeState, setOpeState] = useState({
    opeList: ope,
    pageSize: itemCount === undefined ? 1 : itemCount,
    count,
    currentPage: 1
  });

  useEffect(() => {
    if (searchList.length !== 0) {
      setOpeState(prevState => ({
        ...prevState,
        opeList: searchList
      }));
    } else {
      setOpeState(prevState => ({
        ...prevState,
        opeList: ope
      }));
    }
  }, [searchNum]);

  useEffect(() => {
    setOpeState(prevState => ({
      ...prevState,
      pageSize: itemCount
    }));
  }, [itemCount]);
  //Handle the event and update the state
  const handlePageChange = page => {
    setOpeState(prevState => ({
      ...prevState,
      currentPage: page
    }));
  };

  const opes = paginate(
    opeState.opeList,
    opeState.currentPage,
    opeState.pageSize
  );

  const handleRedirect = id => {
    history.push(`/operators/${id}`);
  };

  const handleDelete = (e, ope) => {
    e.preventDefault();
    setOpeState(prevState => ({
      ...prevState,
      opeList: opeState.opeList.filter(opes => opes._id !== ope._id)
    }));
  };

  const handleEdit = (e, ope) => {
    e.preventDefault();
    setModalData(ope);
    setModal(true);
  };

  const handleAdd = ope => {
    setModalData(ope);
    setModalAdd(true);
  };

  return (
    <>
      <section className="List-wrapper">
        <table className="listWrapper">
          <thead className="listHead">
            <th className="listTitle">Unit</th>
            <th className="listTitle">K_ope name</th>
            {isAdmin ? <th className="listTitle">Edit</th> : null}
          </thead>

          {opes.map(ope => (
            <tbody
              className="listWrapper"
              /* onClick={() => handleRedirect(ope._id)} */
            >
              <tr className="listBody" key={ope._id}>
                <td>{ope._id}</td>
                <td>{ope.name}</td>
                {isAdmin ? (
                  <td>
                    <a
                      href="#"
                      className="crud_icon"
                      onClick={e => handleEdit(e, ope)}
                    >
                      <img src={edit_icon} alt="" />
                    </a>
                    <a
                      href="#"
                      className="crud_icon"
                      onClick={e => handleDelete(e, ope)}
                    >
                      <img src={delete_icon} alt="" />
                    </a>
                  </td>
                ) : null}
              </tr>
            </tbody>
          ))}
        </table>

        {isAdmin ? (
          <div className="modal-add" onClick={() => setModalAdd(true)}>
            Add <span className="modal__add">+</span>
          </div>
        ) : null}
        {modal ? (
          <Modal
            data={modalData}
            setModal={setModal}
            show={modal}
            state={opeState}
            setState={setOpeState}
          />
        ) : null}
        {modalAdd ? (
          <ModalAdd
            state={opeState}
            setState={setOpeState}
            data={modalData}
            show={modalAdd}
            setModal={setModalAdd}
          />
        ) : null}
        <Pagination
          itemsCount={opeState.count}
          pageSize={opeState.pageSize}
          onPageChange={handlePageChange}
          currentPage={opeState.currentPage}
        />
      </section>
    </>
  );
};

export default OpeList;
