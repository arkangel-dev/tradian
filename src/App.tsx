import './App.css'
import Header from './assets/Header.tsx'
import Footer from './assets/Footer.tsx'
import Button from './assets/Button.tsx'
import SearchContainer from './components/SearchContainer.tsx'


function App() {

  return (
    <>
      <Header />


      <div className='r-container relative'>
        <div className='getreadyft'>
          <img className='logo' src='./download.svg'/>
          <h1>Get Ready for Tradian!</h1>
          <p>Phase 1 of Tradian is coming in November. Join our training sessions to master the platform and seamlessly transition your import and export operations to Tradian.</p>

          <div className='mt-10'>
            <Button title='Register for Training' />
          </div>
          <div className='header-info'>
            <h2>Quick Lookup</h2>
            <p>Instantly find declaration status, tariff details and vessel/container tracking</p>
          </div>
          <SearchContainer/>
        </div>
      </div>


      <div className='mt-[15rem]'>

      </div>

      <Footer />
    </>
  )
}

export default App
