import Axios from "axios";
import { url } from "../reducers/Pharmacy";

// function that tells the store to dispatch the fetch pharmacy method with the data from the api call
export const getPharmacy = () => {
    return (dispatch) => {
        return Axios.get(url).then(res => {
            dispatch(fetchpharmacy(res.data));
        }).catch(error => {
            throw (error);
        });
    };
};
//the function dispatched by the store from reducer
export const fetchpharmacy=(pharmacy)=>{
    return{
        type:getPharmacy,
        pharmacy
    }
};
