
import React from 'react';
import './Cards.css';
import CardItem from './CardItem';

function Cards() {
  return (
    <div className='cards'>
      <h1>Dobrodosli u Brcko Distrikt!</h1>
      <div className='cards__container'>
        <div className='cards__wrapper'>
          <ul className='cards__items'>
            <CardItem
              src='images/img-9.jpg'
              text='Dodik jebe mater svima na konferenci između predstavnika parlamenta'
              label='Dodik'
              path='/services'
            />
            <CardItem
              src='images/img-2.jpg'
              text='Novi izbori izasli u Brckom'
              label='Izbor'
              path='/services'
            />
          </ul>
          <ul className='cards__items'>
            <CardItem
              src='images/img-3.jpg'
              text='Nedostatak Novca potreban za stariji narod'
              label='Novac'
              path='/services'
            />
            <CardItem
              src='images/img-4.jpg'
              text='Brcko kao Pejzaz'
              label='Pejzaz'
              path='/products'
            />
            <CardItem
              src='images/img-8.jpg'
              text='Lijepota ovog distrikta'
              label='Distrikt'
              path='/sign-up'
            />
          </ul>
        </div>
      </div>
    </div>
  );
}

export default Cards;
