import Axios from "axios";
import { url} from "../reducers/Pharmacy";

export const createPharmacy=()=>{
    return{
        type:postPharmacy,
        payload:any
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
