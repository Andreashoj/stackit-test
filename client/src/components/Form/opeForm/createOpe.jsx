import React from 'react';
import Heading from "../../Heading/Heading";
import useSignUpForm from '../CustomHooks';

const CreateOpe = () => {

  const {inputs, handleInputChange, handleSubmit} = useSignUpForm(CreateOpe);

    return (
      <>
      <Heading title="Create Operator" desc="Username and password will be send to your email address ."/>
      <form className="opeForm">
        <div className="formGroup">
          <label>Username</label>
          <input type="text" name="username" value={inputs.username} onChange={handleInputChange}/>
        </div>
        <div className="formGroup"> 
            <label>Email</label>
            <input name="email" type="text" value={inputs.email} 
            onChange={handleInputChange}/>
        </div>
        <div className="formGroup">
           <button type="submit" onSubmit={handleSubmit}>Create</button>
        </div>
      </form>
      </>
    )
}

export default CreateOpe;