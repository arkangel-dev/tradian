import './App.css'
import Header from './assets/Header.tsx'
import Footer from './assets/Footer.tsx'
import Button from './assets/Button.tsx'

function App() {

  return (
    <>
      <Header />


      <div className='r-container bg-white'>
        <div className='getreadyft'>
          <h1>Get Ready for Tradian!</h1>
          <p>Phase 1 of Tradian is coming in November. Join our training sessions to master the platform and seamlessly transition your import and export operations to Tradian.</p>

          <div className='mt-10'>
            <Button title='Register for Training'/>
          </div>
        </div>
      </div>


      <Footer />
    </>
  )
}

export default App
