using Connxio.NuGet.Public.Transformation.Interfaces;
using Connxio.NuGet.Public.Transformation.Models;
using Newtonsoft.Json;

namespace Mappingdotnet8test
{
    public class MyFirstConnXioMap : IConnxioMap
    {
        /// <summary>
        /// The method called from the engine when a mapping is executed.
        /// </summary>
        /// <param name="transformationContext">The object containing the message content as it is currently and metadata relevant for the current context</param>
        /// <returns>An instance of TransformationContext. You can return the same instance as the one received in as input parameter, after making some chacges as in the example, or create a brand new one</returns>
        public TransformationContext Map(TransformationContext transformationContext)
        {
            //Add error handling as necessary, this will give better error messages in the logs
            if (transformationContext.Content == null)
                throw new ArgumentException("Content field is null");

            //You can use newtonsoft and other basic nuget packages. Contact the Connxio team if you need a non supported package.
            dynamic obj = JsonConvert.DeserializeObject(transformationContext.Content);
            obj.Prop = "Done";

            //Replace the original content with a string representation of the object "obj"
            transformationContext.Content = JsonConvert.SerializeObject(obj);

            //Return the updated transformationContext
            return transformationContext;
        }
    }
}
