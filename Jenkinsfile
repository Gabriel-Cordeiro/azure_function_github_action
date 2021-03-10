pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        dotnetRestore()
        dotnetTest()
        dotnetPublish(configuration: 'Release')
      }
    }

  }
}