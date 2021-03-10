pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        dotnetRestore()
        dotnetPublish(configuration: 'Realease')
        dotnetTest()
      }
    }

  }
}