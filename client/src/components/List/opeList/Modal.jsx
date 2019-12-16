import React, { useState } from "react";

const Modal = ({ data, setState, show, setModal, state }) => {
  const ShowHideClass = show ? "show modal" : "hide modal";

  const [name, setName] = useState();
  const [id, setId] = useState();

  const handleForm = e => {
    e.preventDefault();
    setState(prevState => ({
      ...prevState,
      opeList: state.opeList.map(ope => {
        if (ope._id === data._id) {
          return { ...ope, name, _id: id };
        } else {
          return ope;
        }
      })
    }));
    setModal(false);
  };

  return (
    <div className={ShowHideClass}>
      <div className="modal-container">
        <div className="modal-container__fit">
          <h2>{data.name}</h2>
          <h3>#{data._id}</h3>

          <form
            className="form-vertical modal-form"
            onSubmit={e => handleForm(e)}
          >
            <label htmlFor="name">Name</label>
            <input
              type="text"
              id="name"
              onChange={e => setName(e.target.value)}
              required
            />
            <label htmlFor="id">Id</label>
            <input
              type="text"
              id="id"
              onChange={e => setId(e.target.value)}
              required
            />
            <input type="submit" value="submit" className="btn submit" />
          </form>
        </div>
      </div>
      <div className="background" onClick={() => setModal(false)}></div>
    </div>
  );
};

export default Modal;
