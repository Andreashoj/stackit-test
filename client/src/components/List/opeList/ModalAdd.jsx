import React, { useState, useContext } from "react";
import http from "../../../services/http";
import { UserContext } from "../../../context/UserContext";

const ModalAdd = ({ state, setState, data, show, setModal }) => {
  const ShowHideClass = show ? "show modal" : "hide modal";

  const { token } = useContext(UserContext);
  const [name, setName] = useState();
  const [id, setId] = useState();

  const handleForm = e => {
    e.preventDefault();
    if (state.machineList) {
      http.post("machines", token, {
        name,
        location: "Loftet",
        companyId: 10,
        statusCodeId: 1
      });
      setModal(false);
    } else {
      setState(prevState => ({
        ...prevState,
        opeList: [...state.opeList, { _id: id, name }]
      }));
      setModal(false);
    }
  };

  return (
    <div className={ShowHideClass}>
      <div className="modal-container">
        <div className="modal-container__fit">
          <form
            className="form-vertical modal-form"
            onSubmit={e => handleForm(e)}
          >
            <h2 className="form__header">
              Add new {state.opeList ? "operator" : "machine"}
            </h2>
            <label htmlFor="name">Name</label>
            <input
              type="text"
              id="name"
              onChange={e => setName(e.target.value)}
              required
            />
            {state.machineList ? (
              <fieldset>
                <div className="input-container">
                  <div className="form-elements">
                    <label forHtml="machine">Select machine</label>
                    <select name="machine" id="machine">
                      <option value="dummy1">Machine1</option>
                      <option value="dummy2">Machine2</option>
                      <option value="dummy3">Machine3</option>
                      <option value="dummy4">Machine4</option>
                    </select>
                  </div>
                  <div className="form-elements">
                    <label for="camFile">Upload CAM</label>
                    <div className="form__upload">
                      <input type="file" name="camFile" id="camFile" />
                      <input
                        type="text"
                        name="camFilename"
                        id="camFilename"
                        className="upload__name"
                      />
                      <button className="upload__button">Search file</button>
                    </div>
                  </div>
                </div>
                <div className="input-container">
                  <div className="form-elements">
                    <label for="machine">Select operator</label>
                    <select name="machine" id="machine">
                      <option value="operator1">Operator1</option>
                      <option value="operator2">Operator2</option>
                      <option value="operator3">Operator3</option>
                      <option value="operator4">Operator4</option>
                    </select>
                  </div>
                  <div className="form-elements">
                    <label for="cadFile">Upload CAD</label>
                    <div className="form__upload">
                      <input type="file" name="cadFile" id="cadFile" />
                      <input
                        type="text"
                        name="cadFilename"
                        id="cadFilename"
                        className="upload__name"
                      />
                      <button className="upload__button">Search file</button>
                    </div>
                  </div>
                </div>
              </fieldset>
            ) : null}{" "}
            <input type="submit" value="submit" className="btn submit" />
          </form>
        </div>
      </div>
      <div className="background" onClick={() => setModal(false)}></div>
    </div>
  );
};

export default ModalAdd;
