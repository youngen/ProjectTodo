namespace ProjectTodo.Domain

open System


module Domain =
    type TaskId = TaskId of Guid
    type Text = Text of string

    type OpenTask = 
        { id        : TaskId 
          text      : Text
          created   : DateTime } //Maybe instant?

    type CompletedTask =
        { id        : TaskId 
          text      : Text
          created   : DateTime
          completed : DateTime }

    type Task =
        | Open of OpenTask
        | Completed of CompletedTask

    module Task =
        let create id text created =
            { id        = id
              text      = text
              created   = created }

        let toCompleted at (openTask:OpenTask) =
            { id = openTask.id
              text = openTask.text 
              created = openTask.created
              completed = at }

        let toOpen (completedTask:CompletedTask) =
            { id = completedTask.id
              text = completedTask.text
              created = completedTask.created }

        let complete at task = toCompleted at task |> Completed
        let openTask task = toOpen task |> Open
        let setText text = function
            | Open t -> Open { t with text = text}
            | Completed t -> Completed { t with text = text }
