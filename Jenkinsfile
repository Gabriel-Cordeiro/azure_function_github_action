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
        azureFunctionAppPublish(deployOnlyIfSuccessful: true, appName: 'publisherNow', resourceGroup: 'TestEventHub', azureCredentialsId: 'AzureCredentials')
      }
    }

  }
}