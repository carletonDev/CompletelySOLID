import Axios from "axios";
import { url} from "../reducers/Pharmacy";

export const createPharmacy=(data)=>{
    return{
        type:postPharmacy,
        payload:{
            pharmacyId:data.pharmacyId,
            pharmacyName:data.pharmacyName,
            pharmacyAddress:data.pharmacyAddress,
            city:data.city,
            state:data.state,
            zip:data.zip,
            pharmacyMedicine:data.pharmacyMedicine,
            salary:data.salary
        }
    }
};

export const postPharmacy = (pharmacy) => {
    return (dispatch) => {
        return Axios.post(url, pharmacy).then(res => {
            dispatch(createPharmacy(res.data));
            if (postStatus == 200) {
                //add a post successful in the ui for post 
            }
        });
    };
};
