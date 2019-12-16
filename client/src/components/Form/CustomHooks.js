import {useState} from "react";
import * as userService  from "../../services/userService";

const useSignUpForm = (callback) => {
    const [inputs, setInputs] = useState({});
    const [errors, setErrors] = useState();

    const handleSubmit = async () => {
        try{    
            await userService.register(inputs);
        }catch(ex){
            if(ex.response && ex.response.status === 400){
                console.log(ex);
            }
        }
    }

    const handleInputChange = (event) => {
        event.persist();
        setInputs(inputs => ({...inputs, [event.target.name]: event.target.value}));
    }

    return{
        handleSubmit,
        handleInputChange,
        inputs
    };
}
export default useSignUpForm;