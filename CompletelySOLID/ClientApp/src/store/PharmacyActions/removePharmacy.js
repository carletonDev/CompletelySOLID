import Axios from "axios";
import { deletePharmacy } from "../reducers/Pharmacy";
export const removePharmacy = id => {
    return {
        type: deletePharmacy,
        payload: {
            id
        }
    };
};
export const removePharmacySuccess = id => {
    return (dispatch) => {
        return Axios.delete('${url}/${id}')
            .then(res => {
                dispatch(removePharmacy(res.data.pharmacyId));
            }).catch(error => {
                throw (error);
            });
    };
};
