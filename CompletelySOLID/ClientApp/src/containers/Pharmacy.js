import PharmacyList from '../components/Pharmacy';
import { connect } from 'react-redux';
import React,{ Component } from 'react';
import { getPharmacy } from '../store/PharmacyActions/getPharmacy'


class PharmacyContainer extends Component
{

        render(){
          return (<PharmacyList/>)
        }
}

const mapStateToProps = (state) => {
    return state
}

export default connect(
    mapStateToProps,
    getPharmacy
)(PharmacyContainer);