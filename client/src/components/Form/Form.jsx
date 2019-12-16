import React from "react";
import useSignUpForm from './CustomHooks';

const Form = () => {

  const {inputs, handleInputChange, handleSubmit} = useSignUpForm(Form);

  return (
    <form onSubmit={handleSubmit} className="form-vertical">
      <fieldset>
        <h2 className="form__header" >Create</h2>
        <div>
          <label for="company">label 1</label>
          <input type="text" name="name" onChange={handleInputChange} value={inputs.firstname} />
        </div>
        <div>
          <label for="name">label 2</label>
          <input type="text" name="company" onChange={handleInputChange} value={inputs.company} />
        </div>
        <div>
          <label for="email">label 3</label>
          <input type="text" name="email" onChange={handleInputChange} value={inputs.email}/>
        </div>
        <button type="submit" className="form__submit" /*value="Create"*/>Create</button>
      </fieldset>
    </form>
  );
};

export default Form;

