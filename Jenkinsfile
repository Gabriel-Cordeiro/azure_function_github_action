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

    stage('Publish') {
      steps {
        azureFunctionAppPublish(deployOnlyIfSuccessful: true, appName: 'publisherNow', resourceGroup: 'TestEventHub', azureCredentialsId: '856b7a6f-0ea9-4ffb-b234-f7dabf9e07db')
      }
    }

  }
}