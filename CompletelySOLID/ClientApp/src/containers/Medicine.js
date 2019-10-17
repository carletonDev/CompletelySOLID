import React, { Component } from "react";
import { connect } from "react-redux";

import * as Actions from '../../src/store/actions/MedicineActions';
import MedicineList from "../components/MedicineList";


class MedicineContainer extends Component{

    render(){
       return(<MedicineList/>)
    }
};

const MapStateToProps=(state)=>{
    return state
};

export default connect(MapStateToProps,Actions.getMedicine)(MedicineContainer)