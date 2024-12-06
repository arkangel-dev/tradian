import './Home.css'
import { Toaster } from 'react-hot-toast';
import Header from '../assets/Header'
import Button from '../assets/Button'
import Footer from '../assets/Footer'
import SearchContainer from '../components/SearchContainer'
import PostListView from './PostListView.jsx'
import toast from 'react-hot-toast';

function Home() {
    return(
        <>
        <div className='r-container relative'>
          <div className='getreadyft'>
            <img className='logo' src='./download.svg' />
            <h1>Get Ready for Tradian!</h1>
            <p>Phase 1 of Tradian is coming in November. Join our training sessions to master the platform and seamlessly transition your import and export operations to Tradian.</p>
  
            <div className='mt-10'>
              <Button onClick={() => toast.error("Not implemented yet") } title='Register for Training' />
            </div>
            <div className='header-info'>
              <h2>Quick Lookup</h2>
              <p>Instantly find declaration status, tariff details and vessel/container tracking</p>
            </div>
            <SearchContainer />
          </div>
        </div>
  
        <div className='mt-[10rem]'></div>
        <PostListView/>
  
      </>
    )
}

export default Home;