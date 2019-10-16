import Axios from "axios";

export const getPharmacy ="getPharmacy";
export const postPharmacy ="newPharmacy";
export const deletePharmacy="deletePharmacy";
export const putPharmacysuccess="putPharmacy";
export const initalState={pharmacy:[]}
export const url ='api/pharmacies';
//method to dispatch with the action type to store list of pharmacies

export const updatepharmacy=(pharmacy)=>{
return {
    type:putPharmacysuccess,
     pharmacy
}
}
//method to dispatch to create a new pharmacy

export const reducer = (state, action) => {
    state = state || initialState;
  // if the action type is equal to this constant string
    if (action.type===getPharmacy) {
      return {
        ...state, //return a copy of the state of the get request and store in pharmacy array
        pharmacy:action.pharmacy
      };
    }
  
    if (action.type === postPharmacy) {
      return {
        ...state,
        payload:action.payload
      };
    }
    if(action.type===deletePharmacy){
       return{ ...state,
        id:action.id
       }
    }
  
    return state;
};
