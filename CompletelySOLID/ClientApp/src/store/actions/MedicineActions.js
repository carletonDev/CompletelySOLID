import Axios from 'axios';
import { list, remove, add } from '../Medicine';
export const getMedicine = () => {
    return (dispatch) => {
        return Axios.get('api/medicine').then(res => {
            dispatch(list(res.data));
        });
    };
};
export const deleteMedicine = (id) => {
    return (dispatch) => {
        return Axios.delete('api/medicine/' + id).then(res => {
            dispatch(remove(res.data.id));
        });
    };
};
export const createMedicine = (medicine) => {
    return (dispatch) => {
        return Axios.post('api/medicine', medicine).then(res => {
            dispatch(add(res.data));
        });
    };
};
