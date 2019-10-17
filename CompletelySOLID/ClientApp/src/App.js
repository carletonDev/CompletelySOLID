import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import MedicineContainer from './containers/Medicine';
import PharmacyContainer from './containers/Pharmacy';

export default () => (
  <Layout>
    <Route exact path='/home' component={Home} />
    <Route path='/counter' component={Counter} />
    <Route path='/fetchdata/:startDateIndex?' component={FetchData} />
    <Route path='/medicinelist' component={MedicineContainer}/>
    <Route path='/pharmacylist' component={PharmacyContainer}/>
  </Layout>
);
