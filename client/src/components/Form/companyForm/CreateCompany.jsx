import React from 'react'
import useSignUpForm from "../CustomHooks";

const CreateCompany = () => {

  const {inputs, handleInputChange, handleSubmit} = useSignUpForm(CreateCompany);

  return (
    <form onSubmit={handleSubmit} className="form-vertical">
      <fieldset>
        <h2 className="form__header" >Create Company</h2>
        <div>
          <label for="company">Company Name</label>
          <input type="text" name="company" onChange={handleInputChange} value={inputs.firstname} />
        </div>
        <div>
          <label for="Create Admin">Create Admin</label>
          <input type="text" name="" onChange={handleInputChange} value={inputs.company} />
        </div>
        <div>
          <label for="email">Email</label>
          <input type="text" name="email" onChange={handleInputChange} value={inputs.email}/>
        </div>
        <button type="submit" className="form__submit" /*value="Create"*/>Create</button>
      </fieldset>
    </form>
  );
}

export default CreateCompany