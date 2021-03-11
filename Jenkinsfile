pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        dotnetClean()
        dotnetRestore()
        dotnetTest()
        dotnetPublish(configuration: 'Release')
      }
    }

    stage('Publish') {
      steps {
        azureFunctionAppPublish(deployOnlyIfSuccessful: true, appName: 'publisherNow', resourceGroup: 'TestEventHub', azureCredentialsId: 'AzureCredentials', filePath: 'zure_function_github_action_main\\src\\Functions\\bin\\Release\\netcoreapp3.1\\')
      }
    }

  }
}