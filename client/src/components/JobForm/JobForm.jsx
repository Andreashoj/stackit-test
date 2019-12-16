import React from "react";
import Heading from "../../components/Heading/Heading";

const JobForm = () => {
  return (
    <div className="job-wrapper">
      <form className="form-wrapper">
        <fieldset>
          <div className="input-container">
            <div className="form-elements">
              <label for="machine">Select machine</label>
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
          <button type="submit" className="form__submit">Create</button>
        </fieldset>
      </form>
    </div>
  );
};

export default JobForm;
